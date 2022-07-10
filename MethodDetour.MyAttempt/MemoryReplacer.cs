using System.Reflection;

namespace MethodDetour.MyAttempt;

public unsafe static class MemoryReplacer
{
    public static void DetourMethod(MethodBase source, MethodBase destination)
    {
        var sourcePtr = (byte*)source.MethodHandle.GetFunctionPointer().ToPointer();
        var destPtr = (byte*)destination.MethodHandle.GetFunctionPointer().ToPointer();

        *(Int64*)(sourcePtr + 1) = destPtr - (sourcePtr + 0x1 + 0x4);
    }
}
