Below is a detailed `.github/copilot-instructions.md` file for your RimWorld modding project in C#:


# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

This mod is designed to enhance the gameplay experience in RimWorld by tweaking the yield of resources obtained from harvesting plants and animals. The mod aims to provide a more balanced and realistic approach to resource management, allowing players to adjust settings to their play style.

## Key Features and Systems

- **Harvest Yield Core**: The primary mod class, `HarvestYieldCore`, is responsible for initializing the mod and managing core functionalities.
- **Animal Yield Adjustment**: The `AnimalYieldPatch` class provides alterations to the yield players receive from animal harvesting, providing a deeper gameplay strategy.
- **Plant Yield Adjustment**: Through the `PlantYieldPatch` class, the mod adjusts the amount of resources players receive when harvesting plants.
- **Settings Integration**: The `HarvestYieldSettings` class allows users to customize the mod's parameters through the in-game settings menu.

## Coding Patterns and Conventions

- **Naming Conventions**: Follow standard C# naming conventions. Class names use PascalCase (e.g., `HarvestYieldCore`), and method names use camelCase.
- **Static Classes for Patches**: Patches are organized into static classes such as `AnimalYieldPatch` and `PlantYieldPatch`. This minimizes instantiation overhead and clarifies their utility as collection points for static methods.
- **Consistent Use of Access Modifiers**: Classes and methods are declared explicitly as `public` or `internal` as appropriate, adhering to encapsulation principles.

## XML Integration

- Utilize XML for defining mod settings and customizing in-game elements. Ensure XML definitions align with RimWorld's modding standards and structure.
- Maintain consistency in tag naming and hierarchy to avoid conflicts or misinterpretations by the game's parser.

## Harmony Patching

- **Method Patching**: Use HarmonyLib to apply non-invasive patches that modify existing game methods. Ensure that `HarmonyPatches` class coordinates patches effectively.
- **Patching Lifecycle**: Implement patches during the appropriate phase of the RimWorld's lifecycle to maximize efficiency and minimize conflicts.
- **Safe Practices**: Safeguard patches with necessary null checks and fallback logic to ensure stability throughout various gameplay scenarios.

## Suggestions for Copilot

1. **Code Suggestions**: Enable suggestions for alternative calculations in yield adjustments to enhance balance and provide variety in gameplay.
2. **Refactoring Assistance**: Use Copilot to recommend refactoring opportunities, making code more readable and maintainable.
3. **Debug Integrations**: Suggest tool integrations or helper methods for easier debugging of Harmony patches, especially when game updates occur.
4. **XML Templates**: Offer XML template assistance when defining new elements or settings to ensure compliance with RimWorld's requirements.
5. **Automated Patch Resolutions**: Provide automated suggestions for potential conflict resolutions in Harmony patches, leveraging machine learning for patterns in patch interactions.

### Conclusion

This instruction file provides a structured approach to collaboratively develop and enhance the mod using GitHub Copilot's capabilities. It encourages a balanced use of automation, creativity, and manual oversight to ensure high-quality and engaging modifications for RimWorld.


This document provides a comprehensive overview of the mod's structure, development guidelines, and suggestions for leveraging GitHub Copilot, tailored to the specific context of RimWorld modding.
