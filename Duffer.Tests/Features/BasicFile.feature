Feature: Basic File output
	In order to use the library
	I want to be able to write basic IDTF files

@mytag
Scenario: empty scene
	Given I have a new current scene
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	"""

Scenario: scene with one model
	Given I have a new current scene
	And the current scene contains a single model named "Model1" 
	And the model named "Model1" has one parent 
	And the model named "Model1" has a resource named "LightBoxModel"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "MODEL" {
		NODE_NAME "Model1"
		PARENT_LIST {
			PARENT_COUNT 1
			PARENT 0 {
				PARENT_NAME "<NULL>"
				PARENT_TM {
					1.000000 0.000000 0.000000 0.000000
					0.000000 1.000000 0.000000 0.000000
					0.000000 0.000000 1.000000 0.000000
					0.000000 0.000000 0.000000 1.000000
				}
			}
		}
		RESOURCE_NAME "LightBoxModel"
	}
	"""
