# GitHub Copilot Instructions for Blueprint Material Debt (Continued)

## Mod Overview and Purpose

Blueprint Material Debt (Continued) is an update of Ben Lubar's mod that subtracts materials needed for blueprints from your stockpiled material count. This mod ensures that you are aware of the materials required for blueprint construction and helps you plan your resource allocation accordingly.

## Key Features and Systems

The mod provides the following key features and systems:

- **Material Debt Calculation**: When a blueprint is selected, the mod calculates the materials required for its construction and subtracts these materials from your stockpiled material count.
- **Toggleable Readouts**: The mod introduces toggleable readouts that allow you to switch between displaying material debt and normal resource counts.
- **Resource Readout Integration**: The mod integrates with the resource readout system to display the material debt in the same interface as other resource counts.

## Coding Patterns and Conventions

When working on the Blueprint Material Debt (Continued) mod, please follow the following coding patterns and conventions:

- **Use Harmonypatch**: This mod uses Harmony to patch existing methods in the RimWorld game. Follow the Harmony patching guidelines provided below.
- **Consistent Naming**: Use consistent naming conventions for your classes, methods, and variables. Follow the C# naming conventions.
- **Modular Code**: Write modular and reusable code. Break down your code into smaller, more manageable classes and methods.

## XML Integration

The mod uses XML for its configuration and metadata. Here are some guidelines for working with XML in this mod:

- **About.xml**: This file contains metadata about the mod, such as its name, author, and version. Ensure that the `Depends on` attribute specifies the required dependencies.
- **Defs.xml**: This file defines the custom game definitions for the mod, such as new items or resources. Follow the XML schema provided by the modding community.

## Harmony Patching

The Blueprint Material Debt (Continued) mod uses Harmony to patch existing methods in the RimWorld game. Here are some guidelines for using Harmony in this mod:

- **Target Method**: Identify the target method that you want to patch. Use the `TargetMethod` attribute to specify the target method.
- **Prefix and Postfix**: Use the `Prefix` and `Postfix` attributes to specify the methods that should be executed before and after the target method, respectively.
- **Harmony Instance**: Use a single instance of the Harmony class throughout your mod. This instance should be initialized in the mod's main class.

## Suggestions for Copilot

Here are some suggestions for using GitHub Copilot with the Blueprint Material Debt (Continued) mod:

- **Generate Harmony Patches**: Use Copilot to generate Harmony patches for existing methods in the RimWorld game. For example, you can use Copilot to generate a patch for the `ResourceReadout.DrawResourceSimple` method.
- **Generate XML Definitions**: Use Copilot to generate XML definitions for custom game definitions, such as new items or resources. For example, you can use Copilot to generate a definition for a new blueprint material.
- **Generate Toggleable Readouts**: Use Copilot to generate toggleable readouts that allow you to switch between displaying material debt and normal resource counts.

By following these guidelines, you can contribute to the Blueprint Material Debt (Continued) mod and improve the modding experience for users.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

