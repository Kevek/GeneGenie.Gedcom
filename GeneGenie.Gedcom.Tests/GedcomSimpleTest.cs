﻿using System;
using System.Linq;
using GeneGenie.Gedcom.Parser;
using Xunit;

namespace GeneGenie.Gedcom.Tests {
  public class GedcomSimpleTest 
  {
    private GedcomRecordReader GetReader(string file) 
    {
      var reader=new GedcomRecordReader();
      reader.ReadGedcom(file);
      return reader;
    }

    [Fact]
    private void File_id() {
      var reader=GetReader(".\\Data\\simple.ged");
      var id=reader.Database.Header.ApplicationName;
      Assert.Equal("ID_OF_CREATING_FILE", id);
    }

    [Fact]
    private void Creator_name() {
      var reader=GetReader(".\\Data\\simple.ged");
      var creatorName=reader.Database.Submitters.SingleOrDefault()?.Name;
      Assert.Equal("/Submitter/", creatorName);
    }

    [Fact]
    private void Creator_address() {
      var reader=GetReader(".\\Data\\simple.ged");
      var creatorAddress=reader.Database.Submitters.SingleOrDefault()?.Address.AddressLine;
      Assert.Equal("Submitters address\r\naddress continued here", creatorAddress);
    }

    [Fact]
    private void Family_count() {
      var reader=GetReader(".\\Data\\simple.ged");
      var familiesCount=reader.Database.Families.Count;
      Assert.Equal(familiesCount, 1);
    }

    [Fact]
    private void Individual_count() {
      var reader=GetReader(".\\Data\\simple.ged");
      var familiesCount=reader.Database.Individuals.Count;
      Assert.Equal(familiesCount, 3);
    }

    [Fact]
    private void Father_name() {
      var reader=GetReader(".\\Data\\simple.ged");
      var father=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Father/");
      Assert.NotNull(father);
    }

    [Fact]
    private void Father_birth_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var father=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Father/");
      Assert.Equal(father?.Birth.Date.DateTime1, new DateTime(1899, 1, 1));
    }

    [Fact]
    private void Father_birth_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var father=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Father/");
      Assert.Equal(father?.Birth.Place.Name, "birth place");
    }

    [Fact]
    private void Father_death_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var father=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Father/");
      Assert.Equal(father?.Death.Date.DateTime1, new DateTime(1990, 12, 31));
    }

    [Fact]
    private void Father_death_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var father=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Father/");
      Assert.Equal(father?.Death.Place.Name, "death place");
    }

    [Fact]
    private void Mother_name() {
      var reader=GetReader(".\\Data\\simple.ged");
      var mother=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Mother/");
      Assert.NotNull(mother);
    }

    [Fact]
    private void Mother_birth_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var mother=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Mother/");
      Assert.Equal(mother?.Birth.Date.DateTime1, new DateTime(1899, 1, 1));
    }

    [Fact]
    private void Mother_birth_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var mother=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Mother/");
      Assert.Equal(mother?.Birth.Place.Name, "birth place");
    }

    [Fact]
    private void Mother_death_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var mother=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Mother/");
      Assert.Equal(mother?.Death.Date.DateTime1, new DateTime(1990, 12, 31));
    }

    [Fact]
    private void Mother_death_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var mother=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Mother/");
      Assert.Equal(mother?.Death.Place.Name, "death place");
    }

    [Fact]
    private void Family_marriage_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var family=reader.Database.Families.SingleOrDefault();
      Assert.Equal(family?.Marriage.Date.DateTime1, new DateTime(1950, 4, 1));
    }

    [Fact]
    private void Family_marriage_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var family=reader.Database.Families.SingleOrDefault();
      Assert.Equal(family?.Marriage.Place.Name, "marriage place");
    }

    [Fact]
    private void Child_name() {
      var reader=GetReader(".\\Data\\simple.ged");
      var child=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Child/");
      Assert.NotNull(child);
    }

    [Fact]
    private void Child_birth_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var child=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Child/");
      Assert.Equal(child?.Birth.Date.DateTime1, new DateTime(1950, 7, 31));
    }

    [Fact]
    private void Child_birth_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var child=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Child/");
      Assert.Equal(child?.Birth.Place.Name, "birth place");
    }

    [Fact]
    private void Child_death_date() {
      var reader=GetReader(".\\Data\\simple.ged");
      var child=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Child/");
      Assert.Equal(child?.Death.Date.DateTime1, new DateTime(2000, 2, 29));
    }

    [Fact]
    private void Child_death_place() {
      var reader=GetReader(".\\Data\\simple.ged");
      var child=reader.Database.Individuals.SingleOrDefault(x => x.GetName().Name=="/Child/");
      Assert.Equal(child?.Death.Place.Name, "death place");
    }
  }
}
