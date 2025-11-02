# Tank Project

A Unity-based tank game project with core mechanics including tank movement, attack, health management, and more.

## Project Structure

The project contains several key C# scripts that implement core game features:

- `TankMovement.cs` - Handles tank movement logic
- `TankAttack.cs` - Implements tank shooting mechanics
- `TankHealth.cs` - Manages tank health and damage system
- `Shell.cs` - Controls projectile behavior
- `FollowTarget.cs` - Camera following logic for tracking tanks
- `TextManager.cs` - Handles in-game text display
- `Exit.cs` - Provides game exit functionality
- `ScoreKeeper.cs` - Manages score tracking
- `ButtonManager.cs` - Handles UI button interactions

## Dependencies

- Unity Engine (compatible with versions supporting the included packages)
- TextMesh Pro - For advanced text rendering
- Simple FX Kit - For particle effects
- Plastic SCM - For version control integration

## Version Control

This project uses Git and Plastic SCM for version control. The repository is hosted at:  
https://github.com/CCDIC/tank.git

### Initial Setup

The repository was initialized with these commands:
```bash
echo "# tank" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/CCDIC/tank.git
git push -u origin main
```

### Version Control Features

- Track pending changes in the **Pending Changes** tab
- View change history in the **Changesets** tab
- Support for inviting team members
- Cloud Edition sign-in support
- Incoming changes notifications
- SSO auto-configuration

## Getting Started

1. Clone the repository
2. Open the project in Unity
3. Explore the main scenes and scripts to understand the game mechanics
4. Use the Plastic SCM integration to manage version control

## License

Fonts included in the project may be subject to their respective licenses (see individual font license files for details). Other project assets and code are available under the project's main license.
