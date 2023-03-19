export ASPNETCORE_ConnectionStrings__MainDb='Host=localhost\;Username=postgres\;Password=root\;Database=weather'
dotnet ef migrations add Init -o Data/Migrations --startup-project '../Weather'
read -p "Press enter to continue"