using System.IO;

namespace ProjetCS.Model; 

public static class PathHelper
{
    // Propriété statique qui calcule et stocke le chemin de la racine de la solution
    public static string SolutionRootPath
    {
        get
        {
            // Cette expression remonte de trois niveaux depuis le dossier d'exécution
            // (Ex: de .../bin/Debug/netX.Y/ vers .../ProjetCSHARP/)
            var currentDir = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentDir)?.Parent?.Parent;

            // Retourne le chemin du dossier racine de la solution
            return parentDir?.FullName ?? currentDir;
        }
    }
}