# ICPMidterm

Water shader:
- Has 2 input colours for the base water colour and wave colour
- Uses a gradient noise texture that is offset based on the time to allow it to flow
- The water works as a kill box for the player

Player multiUV:
- Has a base texture and colour for the default state
- When player dies and respawns, for a brief period of time they cant move and the texture and colour changes using a float value that is updated by the player controller
- Shows the player they cant move during that brief period

Lighting toggle:
- The player material toggles lambert, ambient and specular shading with keys 1, 2 and 3
- All of them toggled off turns it into an unlit material and all of them on turns into a full surface shader
- Like the multiUV, each lighting mode is a float that is toggled through the player controls
- The player is the main focus of the game so the light should focus on it