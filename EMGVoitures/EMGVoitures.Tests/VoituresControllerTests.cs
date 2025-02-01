using Xunit;
using EMGVoitures.Controllers;
using EMGVoitures.Data;
using EMGVoitures.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EMGVoitures.Tests
{
    public class VoituresControllerTests
    {
        // Méthode utilitaire pour créer un contexte de base de données en mémoire
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new ApplicationDbContext(options);

            // Ajouter des données de test
            if (!context.Voitures.Any())
            {
                context.Voitures.AddRange(new List<Voiture>
                {
                    new Voiture { Id = 1, Marque = "Toyota", Modele = "Corolla", Annee = 2020 },
                    new Voiture { Id = 2, Marque = "Honda", Modele = "Civic", Annee = 2021 }
                });
                context.SaveChanges();
            }

            return context;
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfVoitures()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new VoituresController(context);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Voiture>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count); // Vérifie que la liste contient 2 voitures
        }
        [Fact]
        public async Task Create_AddsNewVoiture_AndRedirectsToIndex()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new VoituresController(context);
            var newVoiture = new Voiture { Id = 3, Marque = "Ford", Modele = "Mustang", Annee = 2022 };

            // Act
            var result = await controller.Create(newVoiture);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName); // Vérifie la redirection vers Index
            Assert.Equal(3, context.Voitures.Count()); // Vérifie que la voiture a été ajoutée
        }

        [Fact]
        public async Task Edit_UpdatesVoiture_AndRedirectsToIndex()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new VoituresController(context);
            var updatedVoiture = new Voiture { Id = 1, Marque = "Toyota", Modele = "Corolla", Annee = 2023 };

            // Act
            var result = await controller.Edit(1, updatedVoiture);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName); // Vérifie la redirection vers Index
            var voiture = await context.Voitures.FindAsync(1);
            Assert.Equal(2023, voiture.Annee); // Vérifie que l'année a été mise à jour
        }
    }
}