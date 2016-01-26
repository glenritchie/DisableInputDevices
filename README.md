# DisableInputDevices

<H2>NOTE: Only 64bit compatible atm</H2>

<h1>Purpose</h1>

Allows the user to have certain hardware devices to be automatically disabled/enabled based on a program executed.

It's original intended purpose was because certain Unity3D programs by default accept input <a href="http://docs.unity3d.com/uploads/Main/InputAxis.png">from ALL controllers</a> when assigning an axis. 

This <a href="http://answers.unity3d.com/questions/54366/stuck-movement-in-all-unity-games.html">causes issues</a> if you have a joystick or other controller that has non-standard layout. Such issues appear as "always turning left" or "always turning right".

For me, this was a Logitech Extreme 3D Joystick, and a Razor Orbweaver.

This should rightly be considered a bug in the program/game using Unity3D, although I also suggest Unity3D should not accept intput from ALL devices by default if more than one device is connected, and instead should force the implementing program to allow the user to choose.

<h1>Use</h1>

1. Add the program to trigger enable/disable on the left
2. Add the devices to enable/disable on the right. You may use an any format as described <a href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff544722%28v=vs.85%29.aspx">in this page</a>.

<dd>
<p>Specifies all or part of a hardware ID, compatible ID, or device instance ID of a device. When specifying multiple IDs, type a space between each ID. IDs that include an ampersand character (<strong>&amp;</strong>) must be enclosed in quotation marks. </p>
<p>The following special characters modify the ID parameter.</p>
<div class="contentTableWrapper"><table responsive="true">
<tbody><tr><th>Character</th><th>Description</th></tr>
<tr><td data-th="Character">
<p><strong>*</strong></p>
</td><td data-th="Description">
<p>Matches any character or no character. Use the wildcard character (*) to create an ID pattern, for example, *disk*.</p>
</td></tr>
<tr><td data-th="Character">
<p><strong>@</strong></p>
</td><td data-th="Description">
<p>Indicates a device instance ID, for example, <strong>@ROOT\FTDISK\0000</strong>.</p>
</td></tr>
<tr><td data-th="Character">
<p><strong>'</strong></p>
<p>(single quote)</p>
</td><td data-th="Description">
<p>Matches the string literally (exactly as it appears). Precede a string with a single quote to indicate that an asterisk is part of the ID name and is not a wildcard character, for example, <strong>'*PNP0600</strong>, where *PNP0600 (including the asterisk) is the hardware ID.</p>
</td></tr>
</tbody></table></div>
<p>&nbsp;</p>
</dd>

<h1>Behind the Scenes</h1>
Simply monitors WMI and calls <a href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff544707%28v=vs.85%29.aspx">DEVCON</a> to trigger an enable or disable.
