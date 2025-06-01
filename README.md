# SweetShopSolution

**SweetShopSolution** to aplikacja webowa (ASP.NET Core/Blazor) umożliwiająca zarządzanie sklepem cukierniczym. Projekt umożliwia m.in. zarządzanie produktami, zamówieniami i klientami.

## Funkcje

- ✅ Dodawanie i edycja produktów cukierniczych
- ✅ Zarządzanie zamówieniami i statusem ich realizacji
- ✅ Moduł użytkowników (logowanie, rejestracja)

## 🧩 Struktura projektu

Repozytorium zawiera następujące projekty:

- **Firma.Data**: Warstwa dostępu do danych, zawierająca modele i konfigurację Entity Framework.
- **Firma.Interfaces**: Interfejsy definiujące kontrakty dla usług i repozytoriów.
- **Firma.Services**: Implementacje logiki biznesowej oraz usług aplikacyjnych.
- **Firma.Intranet**: Moduł przeznaczony dla pracowników, umożliwiający zarządzanie produktami, zamówieniami i klientami.
- **Firma.PortalWWW**: Publiczny portal dla klientów, umożliwiający przeglądanie oferty, składanie zamówień oraz rejestrację i logowanie.
