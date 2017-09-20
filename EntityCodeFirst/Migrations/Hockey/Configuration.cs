namespace EntityCodeFirst.Migrations.Hockey
{
    using EntityCodeFirst.Data;
    using EntityCodeFirst.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityCodeFirst.Data.HockeyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Hockey";
        }

        protected override void Seed(EntityCodeFirst.Data.HockeyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            // if it tries to do Canucks again, it will be unique
            context.Teams.AddOrUpdate(t => t.Name,
                getTeams().ToArray());

            context.SaveChanges();

            context.Players.AddOrUpdate(p => new { p.FirstName, p.LastName },
                getPlayers(context).ToArray()
            );

            context.SaveChanges();
        }

        private List<Player> getPlayers(HockeyContext context)
        {
            List<Player> players = new List<Player>()
            {
                new Player()
                {
                    JerseyNumber = 70,
                    FirstName = "Kevin",
                    Position = "Goalie",
                    Country = "Canada",
                    TeamId = context.Teams.FirstOrDefault( t => t.Name == "Canucks").TeamId
                },
                new Player()
                {
                    JerseyNumber = 45,
                    FirstName = "Keanu",
                    Position = "Right Wing",
                    Country = "Africa",
                    TeamId = context.Teams.FirstOrDefault( t => t.Name == "Canucks").TeamId
                },
                new Player()
                {
                    JerseyNumber = 23,
                    FirstName = "Bill",
                    Position = "Center",
                    Country = "Argentina",
                    TeamId = context.Teams.FirstOrDefault( t => t.Name == "Canucks").TeamId
                },
                                new Player()
                {
                    JerseyNumber = 33,
                    FirstName = "John",
                    Position = "Goalie",
                    Country = "France",
                    TeamId = context.Teams.FirstOrDefault( t => t.Name == "Sharks").TeamId
                },
                new Player()
                {
                    JerseyNumber = 103,
                    FirstName = "Will",
                    Position = "Right Wing",
                    Country = "Jumbilaya",
                    TeamId = context.Teams.FirstOrDefault( t => t.Name == "Sharks").TeamId
                },
                new Player()
                {
                    JerseyNumber = 72,
                    FirstName = "Johnny",
                    Position = "Center",
                    Country = "France",
                    TeamId = context.Teams.FirstOrDefault( t => t.Name == "Sharks").TeamId
                }
            };

            return players;
        }

        private List<Team> getTeams()
        {
            List<Team> teams = new List<Team>()
            {
                new Team() { Name="Canucks", City="Vancouver" },
                new Team() { Name="Oilers", City="Edmonton" },
                new Team() { Name="Flames", City="Calgary" },
                new Team() { Name="Sharks", City="Sharks" }
            };

            return teams;
        }
    }
}
