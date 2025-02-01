# EMG Voitures - Site Web de Gestion des Voitures

**EMG Voitures** est une application web permettant de gérer l'inventaire des voitures. Le site permet à un administrateur d'ajouter, modifier et supprimer des voitures, tandis que les utilisateurs peuvent consulter les informations des voitures disponibles. L'application utilise **Microsoft Identity** pour l'authentification, avec des **jetons JWT** pour sécuriser les actions réservées à l'administrateur.

## Fonctionnalités principales

- **Afficher les voitures** : Tous les utilisateurs (internes et externes) peuvent consulter les voitures disponibles à la vente.
- **Ajouter de nouvelles voitures** : Les administrateurs peuvent ajouter de nouvelles voitures dans l'inventaire.
- **Modifier et supprimer des voitures** : Les administrateurs peuvent modifier les informations des voitures existantes (description, photos, etc.) et marquer les voitures comme vendues ou non disponibles.
- **Authentification et autorisation** : Utilisation de **Microsoft Identity** et des **jetons JWT** pour sécuriser l'accès aux fonctionnalités réservées à l'administrateur.
- **Tests unitaires et CI/CD** : Tests unitaires intégrés et pipeline CI/CD pour valider les tests avant le déploiement.

## Technologies utilisées

- **ASP.NET Core** : Framework principal pour la création de l'application web.
- **Microsoft Identity** : Gestion des utilisateurs, des rôles, et de l'authentification.
- **JWT (JSON Web Tokens)** : Utilisé pour l'authentification sécurisée.
- **Entity Framework Core** : ORM pour la gestion des données dans une base de données SQL Server.
- **Swagger** : Documentation et tests des API REST.
- **xUnit** : Framework de test pour les tests unitaires.

## Prérequis

Avant d'exécuter le projet en local, assurez-vous d'avoir les éléments suivants installés :

- **.NET 6.0** ou supérieur (si vous utilisez une version plus récente, mettez à jour les dépendances dans le fichier `Program.cs`).
- **SQL Server** (ou une base de données compatible avec Entity Framework Core).
- **Visual Studio** (recommandé) ou tout autre IDE compatible avec **.NET Core**.

## Installation et configuration

### 1. Cloner le dépôt

Clonez ce dépôt sur votre machine locale en utilisant la commande Git suivante :

```bash
git clone https://github.com/ton-utilisateur/EMGVoitures.git
