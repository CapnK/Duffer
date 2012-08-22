Feature: 'View' Nodes
	In order to create useful IDTF files
	I want to be able to write out View definitions

Scenario: scene with one view
	Given I have a new current scene
	And the current scene contains a view named "DefaultView" 
	And the view named "DefaultView" has a parent called "Parent1" 
	And the parent named "Parent1" has an identity transform matrix
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "VIEW" {
		NODE_NAME "DefaultView"
		PARENT_LIST {
			PARENT_COUNT 1
			PARENT 0 {
				PARENT_NAME "Parent1"
				PARENT_TM {
					1.000000 0.000000 0.000000 0.000000
					0.000000 1.000000 0.000000 0.000000
					0.000000 0.000000 1.000000 0.000000
					0.000000 0.000000 0.000000 1.000000
				}
			}
		}
		VIEW_DATA {
			VIEW_TYPE "PERSPECTIVE"
			VIEW_ATTRIBUTE_SCREEN_UNIT "PIXEL"
			VIEW_PROJECTION 34.515877
		}
	}

	"""
