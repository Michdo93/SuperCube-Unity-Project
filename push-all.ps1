# 1. In den Build-Ordner wechseln und WebGL-Build pushen
Write-Host "Inkrementiere WebGL Build Repo..." -ForegroundColor Cyan
cd Build
git add .

# Pruefen, ob Aenderungen im Build-Ordner vorliegen
$statusBuild = git status --porcelain
if ($statusBuild) {
    git commit -m "Automated WebGL Build Update"
    git push origin main
} else {
    Write-Host "Keine Aenderungen im Build-Ordner gefunden." -ForegroundColor Yellow
}

# 2. Zurück ins Hauptverzeichnis und Unity-Projekt pushen
cd ..
Write-Host "Inkrementiere Unity Projekt Repo..." -ForegroundColor Cyan
git add .

# Pruefen, ob Aenderungen im Hauptprojekt vorliegen (inkl. Submodule-Zeiger)
$statusProject = git status --porcelain
if ($statusProject) {
    git commit -m "Automated Project Update incl. Submodule Pointer"
    git push origin main
} else {
    Write-Host "Keine Aenderungen im Hauptprojekt gefunden." -ForegroundColor Yellow
}

Write-Host "Fertig! Beide Repositories sind geprueft und up to date." -ForegroundColor Green