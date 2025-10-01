# REFACTORIZACIÓN: Clean Architecture + SOLID

Se refactorizó el código original aplicando **Clean Architecture** y principios **SOLID** para lograr un sistema mantenible, extensible y testeable.

---

## 🏛️ ARQUITECTURA EN CAPAS

1.  **Domain Layer**: Entidades (`Cuadrado`, `Circulo`, `TrianguloEquilatero`, `Trapecio`), Interfaces (`IFormaGeometrica`, `ILocalizacionService`, `IReporteService`, `IReporteFormatter`) y Models (`ReporteResultado`). No tiene dependencias externas.

2.  **Application Layer**: `ReporteService` (caso de uso para generar reportes). Depende solo de la capa de Dominio.

3.  **Infrastructure Layer**: `LocalizacionService` (utiliza archivos `.resx` para internacionalización) y `HtmlReporteFormatter` (se encarga de la generación de reportes en HTML). Depende de la capa de Dominio.

4.  **Presentation Layer**: Esta capa está representada por la clase legacy que actúa como *wrapper*, los tests y la aplicación de consola.

---

## ✨ PRINCIPIOS SOLID

* **S - Single Responsibility Principle**: Cada clase tiene una única responsabilidad (ej: `Cuadrado` solo se ocupa de sus cálculos geométricos, `ReporteService` solo genera el reporte, `HtmlReporteFormatter` solo formatea a HTML).

* **O - Open/Closed Principle**: El sistema es extensible sin necesidad de modificar código existente (se pueden agregar nuevas formas geométricas implementando `IFormaGeometrica` o nuevos idiomas agregando un archivo `.resx`).

* **L - Liskov Substitution Principle**: Todas las formas geométricas son intercambiables y sustituibles a través de la interfaz `IFormaGeometrica`.

* **I - Interface Segregation Principle**: Se definieron interfaces pequeñas y específicas para cada necesidad (`IFormaGeometrica`, `ILocalizacionService`, `IReporteFormatter`, `IReporteService`).

* **D - Dependency Inversion Principle**: Las clases dependen de abstracciones (interfaces) y no de implementaciones concretas (ej: `ReporteService` depende de `IFormaGeometrica` e `ILocalizacionService`, no de las clases `Cuadrado` o `LocalizacionService`).
