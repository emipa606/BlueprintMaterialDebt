# .github/copilot-instructions.md

## Mod Overview and Purpose

The `BlueprintMaterialDebt` mod for RimWorld introduces enhanced resource management features, specifically focusing on aiding players in tracking material debt incurred through blueprint placement. The primary goal of this mod is to provide visual indicators and controls to help players efficiently manage their resource consumption and ensure smoother construction and development within the game.

## Key Features and Systems

- **Blueprint Material Debt Tracking**: The mod provides a system for tracking and displaying the materials owed due to placed blueprints, allowing players to better manage their resources and prioritize construction tasks.
- **Toggleable Resource Readout**: A feature that allows players to toggle between different resource readout modes, providing a customizable UI experience focused on resource management.
- **Enhanced Resource Counter**: An updated resource counter that integrates directly into RimWorld’s UI, offering real-time updates on resource availability and debt.

## Coding Patterns and Conventions

- **Class Structures**: The mod comprises several static classes, structured to facilitate extension and maintainability. Internal static classes are used for utility functions, promoting encapsulation and modularity.
  
- **Method Signatures**: All methods within the internal utility classes are static. This approach reduces the overhead associated with instance creation and aligns well with the procedural approach taken by the mod.

- **Naming Conventions**: CamelCase is employed for method names, class names are in PascalCase, and all identifiers are created to be descriptive, improving code readability and maintenance.

## XML Integration

While the current summary does not include explicit XML configuration details, the mod likely integrates XML for defining custom objects, events, and UI elements. Suggested patterns include:

- Define XML elements for customizable settings or adding new entries or patches into RimWorld's existing XML structure.
- Ensure XML files are appropriately structured and leverage RimWorld's native schema validation for integration with the base game.

## Harmony Patching

- **Harmony Integration**: Uses Harmony for runtime method patching. This technique allows for modification of existing game methods without altering the base game code directly.
  
- **Patch Types**: It’s crucial to use the correct patch type (Prefix, Postfix, Transpiler) based on the intended modification:
  - **Prefixes**: Used to modify or override the behavior before the original method execution.
  - **Postfixes**: Applied after the original method execution to modify the results or state.
  - **Transpilers**: Employed for complex method modifications that involve altering the IL code.

- **Patch Targets**: Carefully determine target methods by examining RimWorld's binaries, ensuring compatibility across game versions.

## Suggestions for Copilot

- **Pattern Recognition**: Utilize Copilot to recognize existing patterns, such as method signatures and class structures. Encourage code suggestions that align with established naming conventions and class responsibilities.

- **Code Completion**: Benefit from Copilot's code completion to speed up repetitive coding tasks, such as method stubs and debugging constructs.

- **Complex Code Constructs**: Allow Copilot to assist in drafting Harmony patches and XML integration snippets, harnessing its proficiency in generating contextually appropriate code fragments.

- **Error Avoidance**: Leverage Copilot’s ability to predict potential points of failure and offer improvements or error handling templates, particularly when modifying game behavior through patches.

Remember to regularly review and test any code generated by Copilot for functional accuracy and alignment with the mod's objectives.
