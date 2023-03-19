export ASPNETCORE_ConnectionStrings__MainDb='Host=localhost;Port=5432;Username=postgres;Password=root;Database=weather'
dotnet ef database update -s '../Weather'
read -p "Press enter to continue"