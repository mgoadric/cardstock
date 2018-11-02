.. RECYCLED CardStock documentation master file, created by
   sphinx-quickstart on Mon Jul 30 11:02:55 2018.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

******************
RECYCLEd CardStock
******************

Overview
========

CardStock is a General Game Playing engine for card games implemented 
in C#. Games are written in RECYCLE, a card game description language, and
then simulations are run with random, simple, and complex AI players. CardStock can then
analyze the games to determine heuristics about the games
such as fairness, decisiveness, drama, or clarity, and generate transcripts of
each simulation for further study.

There are currently 30 games coded in RECYCLE, from genres such as 
press-your-luck, fishing, adding, matching, draw-and-discard, and trick-taking
games. 

.. Attention:: We are currently in the process of abstracting and refactoring CardStock to allow
   for new game functionality and setting up a modular system for a
   tournament of AI players. Please check back for further progress on these issues.

Requirements
============

Visual Studio

- Mac_
- Windows_ 
	
.. _Mac: https://www.visualstudio.com/vs/visual-studio-mac/
.. _Windows: https://visualstudio.microsoft.com/vs/

Code
====

Source code available at Github_

.. _Github: https://github.com/mgoadric/cardstock

.. toctree::
   :maxdepth: 2
   :caption: Contents:
   
   recycle/index
   cardstock/index
   aiplayers/index

