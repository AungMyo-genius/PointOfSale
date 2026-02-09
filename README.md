# Point Of Sale (MAUI Blazor Hybrid + SQLite)

This repository provides a .NET 10 MAUI Blazor Hybrid point-of-sale starter with inventory management, reporting, and SQLite persistence. It is designed for small businesses that need full visibility across sales, inventory, customers, employees, and financial performance.

## Key Features

- **MAUI Blazor Hybrid UI** with a dashboard, report catalog, and inventory workflows.
- **SQLite-backed data model** using Entity Framework Core.
- **Reporting services** ready to compute sales, inventory, customer, employee, and financial summaries.
- **Extensible domain model** for products, purchase orders, goods received, shrinkage, and gift cards.

## Report Coverage

The report catalog page includes all of the reports described in the requirements:

- Sales tracking (daily summaries, trends, product/category, time/daypart, customer, discounts).
- Inventory management (on hand, low stock, velocity, turnover, COGS, POs, GRN, shrinkage, expiry).
- Customer insights (top customers, purchase history, loyalty segments, retention).
- Employee performance (sales, transactions, shift productivity, training).
- Financial (daily/session totals, Z-report, tax summary, tender types, P&L, refunds, promo costs, gift cards).

## Getting Started

1. Install .NET 10 preview and MAUI workload.
2. Restore packages and run the app:
   ```bash
   dotnet restore
   dotnet build
   dotnet maui run
   ```

## Project Structure

- `src/PointOfSale.App` - MAUI Blazor Hybrid application.
  - `Data/` EF Core DbContext.
  - `Models/` POS domain entities and report DTOs.
  - `Services/` Reporting and inventory services.
  - `Pages/` Blazor views.
  - `Shared/` Layout components.
