using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

Console.WriteLine("Hello!");

foreach(var type in typeof(X86Base).Assembly.GetTypes().Where(x => (typeof(X86Base).IsAssignableFrom(x) || typeof(ArmBase).IsAssignableFrom(x)) && x.GetProperty("IsSupported") is not null))
{
    var prop = type.GetProperty("IsSupported")!;
    Console.WriteLine($"{type.Namespace![(type.Namespace!.LastIndexOf(".") + 1)..]} {type.Name} => {(((bool)prop.GetValue(null)!) ? "Support" : "Not Support")}");
}

return;
