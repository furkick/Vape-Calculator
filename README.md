# Vape-Calculator
DIY E-Liquid Calculator for recipes to convert from ml to grams for accurate juice creation. 

Please note this is in *Beta* so therefore is not a finished piece of software.

# Dependencies

The following dependency is **required** for the software to function:

- [LiteDB](http://www.litedb.org/) **v2.0.4**

## Main Calculator

The main calculator is used to create the actual juice recipe to produce in grams.
### Features

- Ability to save, update and delete the recipe using LiteDB.
- Dropdown controls populated by your saved flavours/concentrates (the weight value is passed into the calculation).
- Button to refresh form to clear controls.
- Change from PG nicotine to VG using checkbox.

<p align="center">
    <img src="https://s29.postimg.org/m9g6294hz/One.png" />
</p>

## List of Saved Flavours

The flavours form is used to create, update and delete your flavours/concentrates. **Note:** currently the flavours will only calculate based on a PG base not VG or alcohol, please bear in mind of this when using the calculator. This will be changed in a future release.
### Features

- Ability to save, update and delete your flavours/concentrates using LiteDB.
- Text boxes populate the name and weight (per ml) of a saved flavour.
- Button to create a new flavour.

<p align="center">
    <img src="https://s29.postimg.org/u8bc5irw7/Two.png" />
</p>


## Creating a New Flavour

The new flavours form is used to create a new flavour for your recipes.
### Features

- Ability to create a new flavour/concentrate using LiteDB.
- Text boxes to input the name and weight (per ml) of a new flavour.

<p align="center">
    <img src="https://s27.postimg.org/9aoadlf4j/Three.png" />
</p>

# Issues

Please check if the issue currently exists before submitting a new issue, otherwise open issue in github.

# Contributing

You are more than welcome to contribute to the repo.

# Author

Christoper Halfpenny [@furkick](https://github.com/furkick)

# Licence

Vape Calculator is copyright 2017 Christopher Halfpenny and contributors. It is licensed under the MIT License. See the included LICENSE file for more details.