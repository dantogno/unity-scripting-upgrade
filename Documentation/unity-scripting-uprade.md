---
title: "Unity Scripting Upgrade"
author: dantogno
ms.author: v-davian
ms.date: 07/06/2018
ms.topic: sample
ms.assetid:
---
# Unity Scripting Upgrade

C# and .NET, the technologies underlying Unity scripting, have continued to receive updates since Microsoft originally released them in 2002. But Unity developers may not be aware of the steady stream of new features added to the C# language and .NET Framework. That's because prior to the release of Unity 2017.1, Unity has been using a .NET 3.5 equivalent scripting runtime, missing over 10 years of updates!

With the release of Unity 2017.1, Unity introduced an experimental version of its core scripting runtime upgraded to a .NET 4.6 compatible version. In Unity 2018.1, the .NET 4.x equivalent runtime is no longer considered "experimental" and has been rebranded as "stable," while the older .NET 3.5 equivalent runtime is now considered "legacy." And with the release of Unity 2018.3, Unity is projecting to make the upgraded scripting runtime the default selection. For more information and the latest updates on this roadmap, you can visit Unity's [Experimental Scripting Previews forum](https://forum.unity.com/forums/experimental-scripting-previews.107/). In the meantime, check out the sections below to learn more about these new features and how to use them.

## Prerequisites

* [Unity 2017.1 or above](https://unity3d.com/)
* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/)

## Enabling the .NET 4.x scripting runtime in Unity

1. Open PlayerSettings in the Unity Inspector by selecting **Edit > Project Settings > Player**.

1. Under the **Configuration** heading, click the **Scripting Runtime Version** dropdown and select **.NET 4.x Equivalent**.

![Select .NET 4.x equivalent](media/vstu_scripting-runtime-version.png)