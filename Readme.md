# UniThesis – Guia Rápido (PowerShell)

## 🔧 Criar Migration

```powershell
dotnet ef migrations add InitialCreate `
  -p UniThesis.Infrastructure `
  -s UniThesis.WebApi `
  -o Persistence/Migrations
```

## 🔧 Atualizar Banco

```powershell
dotnet ef database update `
  -p UniThesis.Infrastructure `
  -s UniThesis.WebApi
```

## 🔧 Dropar Banco

```powershell
dotnet ef database drop `
  -p UniThesis.Infrastructure `
  -s UniThesis.WebApi
```

## 🔧 Gerar script SQL

```powershell
dotnet ef migrations script `
  -p UniThesis.Infrastructure `
  -s UniThesis.WebApi
```

---

# 🐳 Docker (opcional)

Subir API + SQL com Docker:

```powershell
docker compose up --build
```

Parar:

```powershell
docker compose down
```

---

# 🔑 Logins Seed

* **Coordenador**
  user: `coord1`
  pass: `Senha123!`

* **Professor**
  user: `prof1`
  pass: `Senha123!`

* **Aluno**
  user: `aluno1`
  pass: `Senha123!`

---
