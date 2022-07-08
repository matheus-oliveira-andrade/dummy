using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    [Solution] readonly Solution Solution;
    
    public static int Main() => Execute<Build>(x => x.Test);

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(x =>
                x.SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(x => x
                .EnableNoRestore()
                .SetProjectFile(Solution));
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(x => x
                .SetProjectFile(Solution));
        });
}