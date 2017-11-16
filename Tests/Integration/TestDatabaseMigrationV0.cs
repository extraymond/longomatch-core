﻿//
//  Copyright (C) 2015 Fluendo S.A.
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
using System.IO;
using LongoMatch;
using LongoMatch.Core.Store;
using LongoMatch.DB;
using LongoMatch.Services;
using Moq;
using NUnit.Framework;
using VAS.Core.Interfaces;
using VAS.Core.Interfaces.GUI;
using VAS.Core.Interfaces.License;
using VAS.Core.Interfaces.Multimedia;

namespace Tests.Integration
{
	[TestFixture]
	public class TestDatabaseMigrationV0
	{
		Mock<IGUIToolkit> guiToolkitMock;
		Mock<IMultimediaToolkit> multimediaToolkitMock;
		Mock<IVideoPlayer> player;
		Mock<ILicenseManager> mockLicenseManager;
		Mock<ILicenseStatus> mockLicenseStatus;
		Mock<ILicenseLimitationsService> mockLicenseLimitationService;
		ILicenseManager currentLicenseManager;
		ILicenseLimitationsService currentLimitationService;

		[OneTimeSetUp]
		public void TestFixtureSetUp ()
		{
			Directory.SetCurrentDirectory (TestContext.CurrentContext.TestDirectory);
			guiToolkitMock = new Mock<IGUIToolkit> ();
			multimediaToolkitMock = new Mock<IMultimediaToolkit> ();
			player = new Mock<IVideoPlayer> ();
			multimediaToolkitMock.Setup (g => g.GetPlayer ()).Returns (player.Object);
			currentLicenseManager = App.Current.LicenseManager;
			currentLimitationService = App.Current.LicenseLimitationsService;
		}

		[OneTimeTearDown]
		public void TestFixtureTearDown ()
		{
			App.Current.LicenseManager = currentLicenseManager;
			App.Current.LicenseLimitationsService = currentLimitationService;
		}

		[SetUp]
		public void SetUp ()
		{
			mockLicenseManager = new Mock<ILicenseManager> ();
			mockLicenseStatus = new Mock<ILicenseStatus> ();
			mockLicenseManager.SetupGet ((lm) => lm.LicenseStatus).Returns (mockLicenseStatus.Object);
			mockLicenseLimitationService = new Mock<ILicenseLimitationsService> ();
		}

		[TearDown]
		public void Reset ()
		{
			SetupClass.SetUp ();
			try {
				App.Current.StopServices ();
			} catch {
			}
		}

		[Test ()]
		public void TestMigratingOldDatabase ()
		{
			string tmpPath = Path.Combine (Path.GetTempPath (), Path.GetRandomFileName ());
			string homePath = Path.Combine (tmpPath, "LongoMatch");
			string dbPath = Path.Combine (homePath, "db");
			string lmdbPath = Path.Combine (dbPath, "longomatch.ldb");
			string teamsPath = Path.Combine (dbPath, "teams");
			string dashboardsPath = Path.Combine (dbPath, "analysis");

			Directory.CreateDirectory (tmpPath);
			Directory.CreateDirectory (homePath);
			Directory.CreateDirectory (dbPath);
			Directory.CreateDirectory (lmdbPath);
			Directory.CreateDirectory (teamsPath);
			Directory.CreateDirectory (dashboardsPath);

			Utils.SaveResource ("spain.ltt", teamsPath);
			Utils.SaveResource ("france.ltt", teamsPath);
			Utils.SaveResource ("basket.lct", dashboardsPath);
			Utils.SaveResource ("spain_france_test.lgm", lmdbPath);

			// Create an empty project file that shouldn't be converter
			File.Open (Path.Combine (lmdbPath, "empty.lgm"), FileMode.Create);

			Directory.CreateDirectory (tmpPath);
			Environment.SetEnvironmentVariable ("LONGOMATCH_HOME", tmpPath);
			Environment.SetEnvironmentVariable ("LGM_UNINSTALLED", "1");
			App.Init ();
			CoreServices.Init ();
			App.Current.LicenseManager = mockLicenseManager.Object;
			App.Current.LicenseLimitationsService = mockLicenseLimitationService.Object;
			App.Current.StartServices ();

			Assert.AreEqual (0, App.Current.DatabaseManager.ActiveDB.Count<LMProject> ());
			Assert.AreEqual (2, App.Current.TeamTemplatesProvider.Templates.Count);
			Assert.AreEqual (1, App.Current.CategoriesTemplatesProvider.Templates.Count);

			DatabaseMigration dbMigration = new DatabaseMigration (Mock.Of<IProgressReport> ());
			dbMigration.Start ();

			App.Current.DatabaseManager.SetActiveByName ("longomatch");
			Assert.AreEqual (4, App.Current.TeamTemplatesProvider.Templates.Count);
			Assert.AreEqual (2, App.Current.CategoriesTemplatesProvider.Templates.Count);
			Assert.AreEqual (1, App.Current.DatabaseManager.ActiveDB.Count<LMProject> ());

			Assert.IsTrue (File.Exists (Path.Combine (dbPath, "templates", "backup", "spain.ltt")));
			Assert.IsTrue (File.Exists (Path.Combine (dbPath, "templates", "backup", "france.ltt")));
			Assert.IsTrue (File.Exists (Path.Combine (dbPath, "templates", "backup", "basket.lct")));
			Assert.IsTrue (File.Exists (Path.Combine (dbPath, "old", "longomatch.ldb", "spain_france_test.lgm")));

			App.Current.StopServices ();
		}

		[Test]
		public void TestNoOldDatabaseToMigrate ()
		{
			string tmpPath = Path.Combine (Path.GetTempPath (), Path.GetRandomFileName ());
			string homePath = Path.Combine (tmpPath, "LongoMatch");
			string dbPath = Path.Combine (homePath, "db");
			string lmdbPath = Path.Combine (dbPath, "longomatch.ldb");
			string teamsPath = Path.Combine (dbPath, "teams");
			string dashboardsPath = Path.Combine (dbPath, "analysis");

			Directory.CreateDirectory (tmpPath);
			Directory.CreateDirectory (homePath);

			Environment.SetEnvironmentVariable ("LONGOMATCH_HOME", tmpPath);
			Environment.SetEnvironmentVariable ("LGM_UNINSTALLED", "1");
			App.Init ();
			CoreServices.Init ();
			App.Current.LicenseManager = mockLicenseManager.Object;
			App.Current.LicenseLimitationsService = mockLicenseLimitationService.Object;
			App.Current.StartServices ();

			Assert.AreEqual (0, App.Current.DatabaseManager.ActiveDB.Count<LMProject> ());
			Assert.AreEqual (2, App.Current.TeamTemplatesProvider.Templates.Count);
			Assert.AreEqual (1, App.Current.CategoriesTemplatesProvider.Templates.Count);

			DatabaseMigration dbMigration = new DatabaseMigration (Mock.Of<IProgressReport> ());
			dbMigration.Start ();

			Assert.AreEqual (0, App.Current.DatabaseManager.ActiveDB.Count<LMProject> ());
			Assert.AreEqual (2, App.Current.TeamTemplatesProvider.Templates.Count);
			Assert.AreEqual (1, App.Current.CategoriesTemplatesProvider.Templates.Count);

			// Directory exists but it's empty
			Directory.CreateDirectory (dbPath);
			Directory.CreateDirectory (lmdbPath);
			Directory.CreateDirectory (teamsPath);
			Directory.CreateDirectory (dashboardsPath);

			dbMigration = new DatabaseMigration (Mock.Of<IProgressReport> ());
			dbMigration.Start ();

			Assert.AreEqual (0, App.Current.DatabaseManager.ActiveDB.Count<LMProject> ());
			Assert.AreEqual (2, App.Current.TeamTemplatesProvider.Templates.Count);
			Assert.AreEqual (1, App.Current.CategoriesTemplatesProvider.Templates.Count);

			App.Current.StopServices ();
		}
	}
}
