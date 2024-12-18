
Clone your repository
git clone https://github.com/prasanthNasaka/RacingApp.git

Navigate to the cloned directory
cd RacingApp 

Verify Docker Compose is installed
docker-compose --version

Build
docker-compose build

compose
docker-compose up -d

Verify that the containers are running
docker ps

Build and start the containers
docker-compose up --build

new tables Scaffold
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=DummyProjectSql;Username=postgres;Password=1234" Npgsql.EntityFrameworkCore.PostgreSQL -o Models

update tables Scaffold
dotnet ef dbcontext scaffold "Host=localhost;Port=5431;Database=DummyProjectSql;Username=postgres;Password=1234" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f

