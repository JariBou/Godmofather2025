using UnityEngine;

namespace _project.Scripts.Enigmas.PhEnigma.Interfaces
{
    public interface IPhDetectorSpawner
    {
        void Release();
        void Reserve();
        
        Vector3 GetOverPosition();
        Vector3 GetOverRotation();
    }
}