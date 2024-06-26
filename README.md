# Numérologie : le chemin de vie et la résonance vibratoire
[![build](https://github.com/numeriquerelais/NumerologicalLifePath/actions/workflows/CI.yml/badge.svg)](https://github.com/numeriquerelais/NumerologicalLifePath/actions/workflows/CI.yml) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=numeriquerelais_NumerologicalLifePath&metric=bugs)](https://sonarcloud.io/summary/new_code?id=numeriquerelais_NumerologicalLifePath) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=numeriquerelais_NumerologicalLifePath&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=numeriquerelais_NumerologicalLifePath) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=numeriquerelais_NumerologicalLifePath&metric=coverage)](https://sonarcloud.io/summary/new_code?id=numeriquerelais_NumerologicalLifePath) [![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=numeriquerelais_NumerologicalLifePath&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=numeriquerelais_NumerologicalLifePath) 

[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=numeriquerelais_NumerologicalLifePath)](https://sonarcloud.io/summary/new_code?id=numeriquerelais_NumerologicalLifePath)

[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2Fnumeriquerelais%2FNumerologicalLifePath%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/numeriquerelais/NumerologicalLifePath/main)

Le but de ce projet est de prendre du plaisir, d'apprendre et de faire un travail de qualité en mettant en place :
- Les règles de calcul numérologique à partir de la date de naissance et des noms et prénoms d'une personne pour déterminer :
  - [x] les pierres de son chemin de vie 
  - [x] les chiffres en résonance vibratoire avec sa date de naissance
  - [x] la grille d'inclusion
- Découvrir :
  - [x] la mise en place dans github d'une CI à partir de github actions
	- [x] dependabot
  - [x] l'interpréteur de ligne de commande .Net
  - [x] ApprovalTests

## Utilisation
### Calcul des pierres du chemin de vie
```cmd
NumerologicalTool lifePath -f "Simon Roger" -l "Federer Connors" -d "15/02/1955"
```
- -f : la liste des prénoms séparés par un espace
- -l : la liste de noms de famille (nom du père, nom de la mère) séparés par un espace
- -d : la date de naissance au format jj/MM/AAAA

### Calcul des chiffres en résonance vibratoire avec sa date de naissance
```cmd
NumerologicalTool birthStones -d "15/02/1955"
```
- -d : la date de naissance au format jj/MM/AAAA

### Calcul de la grille d'inclusion
```cmd
NumerologicalLifePath.Application inclusionGrid -f \"Marc Luc Matthieu Jean\" -l \"Dubuisson Laforêt\"
```
- -f : la liste des prénoms séparés par un espace
- -l : la liste de noms de famille (nom du père, nom de la mère) séparés par un espace

### Calcul de la grille d'inclusion
```cmd
NumerologicalTool inclusionGrid -f \"Marc Luc Matthieu Jean\" -l \"Dubuisson Laforêt\"
```
- -f : la liste des prénoms séparés par un espace
- -l : la liste de noms de famille (nom du père, nom de la mère) séparés par un espace

## Règles
### Table de correspondance lettre - chiffre
| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
| -- | -- | -- | -- | -- | -- | -- | -- | -- |
| A | B | C | D | E | F | G | H | I |
| J | K | L | M | N | O | P | Q | R |
| S | T | U | V | W | X | Y | Z |  |

### Les règles de calcul du chemin de vie
[Documentation n°1](https://www.chakras-shop.com/bien-etre/lithotherapie/bracelet-chemin-de-vie/)
[Documentation n°2](http://bijouxlithotherapie.eklablog.com/calcul-des-pierres-du-chemin-de-vie-c29433368)

### Résonance vibratoire
[Caractéristiques des chiffres](https://www.france-mineraux.fr/numerologie/chiffres/)

### Grille d'inclusion
[Grille d'inclusion](https://kabalistik.com/apprendre/1-abrege-de-numerologie.html)
[Grille d'inclusion 2](https://www.numerologueconseils.com/index.php/articles-de-numerologie-gratuite/2-non-categorise/24-l-inclusion-la-cle-numerologique)
[Grille d'inclusion 2](https://www.myrddinshome.fr/numerologie-nom-2/)

## Ressources complémentaires
### Documentation technique
[Dependabot](https://medium.com/@nickfane/integrating-dependabot-into-your-net-core-project-on-github-3e3024bd3394)
[Command Line](https://learn.microsoft.com/fr-fr/dotnet/standard/commandline/get-started-tutorial)
[Clean CLI](https://github.com/NikiforovAll/clean-cli-todo-example/tree/main/src/CleanCli.Todo.Console)
[ApprovalTests tutoial](https://lassiautio.com/2018/03/18/approvaltests-one-of-my-favorite-nuget/)
[Publish .Net Artifact](https://elanderson.net/2020/06/github-use-actions-to-publish-artifacts/)
[Publish .Net Artifact 2](https://github.com/bcr/dotnet-actions-gitflow)

### Sonar Cloud
[SonarCloud Coverage failed](https://community.sonarsource.com/t/test-coverage-always-on-0-net-core-github-action/64347/11)
[SonarCloud YML](https://stackoverflow.com/questions/58871955/sonarcloud-code-coverage-remains-0-0-in-github-actions-build)
[SonarCloud YML sample](https://github.com/brenordv/validator-dot-net/blob/master/.github/workflows/build.yml)
[SonarCloud forum](https://community.sonarsource.com/t/net-github-actions-0-coverage/114718)

### Stryker Mutator
[help](https://stryker-mutator.io/docs/General/dashboard/#send-your-first-report)
[my repo](https://dashboard.stryker-mutator.io/repos/numeriquerelais)
[tutorial](https://medium.com/@hamed.shirbandi/mutation-testing-with-stryker-in-net-projects-ff1f05ddce8f)

### Auteur
[![build](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/cyril-cophignon-b58b5a5b/)