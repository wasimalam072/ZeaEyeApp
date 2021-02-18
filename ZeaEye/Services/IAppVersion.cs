using System;
namespace ZeaEye.Services
{
    public interface IAppVersion
    {
        string GetVersion();
        int GetBuild();
    }
}
