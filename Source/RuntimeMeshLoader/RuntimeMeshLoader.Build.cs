// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class RuntimeMeshLoader : ModuleRules
{
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }

    public RuntimeMeshLoader(ReadOnlyTargetRules Target) : base(Target)
    {
        PublicIncludePaths.AddRange(
			new string[] {
				"RuntimeMeshLoader/Public",
                Path.Combine(ThirdPartyPath, "assimp/include")
			}
		);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				"RuntimeMeshLoader/Private",
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
                "CoreUObject",
                "Engine",
                "RHI",
                "RenderCore",
                "ProceduralMeshComponent"
			}
			);


        PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Slate",
				"SlateCore",
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
            }
            );

        if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
        {
            string PlatformString = (Target.Platform == UnrealTargetPlatform.Win64) ? "x64" : "x86";
            PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, "assimp/lib",PlatformString, "assimp-vc140-mt.lib"));

            RuntimeDependencies.Add(new RuntimeDependency(Path.Combine(ThirdPartyPath, "assimp/bin",PlatformString, "assimp-vc140-mt.dll")));
        }
    }
}
