# Money Keeper - Personal Financial Management App

Our self-build application for our personal financial management. Also we are learning fullstack development with this first application.

We are focussing on following main features for this application:

- Categories for transaction, support for sub-category
- Accounts and Account Group, group includes multiple of accounts
- Supporting account types: expense, goal, credit
- Setting weekly, monthly budgets by category or
- Show report by a date time range:
    - Transaction amounts by category, monthly, type of transaction
    - Total balance by account, monthly
    - Predict the goal completion time by using line regression
- [Exclusion: transaction from report, account balance from totals]

## Setup development environment

Prerequisite:

- PostgreSQL Database version 15.0, having a database with name `moneykeeper` also set the owner to `mk_admin` user.
- .NET 6.0 is the platform used to develop this application's backend
- nodejs v18.16.0 is the platform used to develop this application's frontend
- If you are using Visual Studio, you can use the **Package Manager Console** tool to run the database migration. Otherwise, you should install `dotnet tool install --global dotnet-ef` to run the migration with the CLI.

### For the first time run this solution 

1. On the file `appsettings.Development.json` update the connection string with the name, username, password that you configured on PostgreSQL.
2. If using the Visual Studio, you can open **Package Manager Console** and run the command `update-database` to generate schemas on new database.
3. If you are not using VS, you can run it with installed entity framework .NET tool via the command `dotnet ef database update` in **datntdev.MoneyKeeper.WebApi** directory.

### For run the frontend development server

```bash
npm run dev
```