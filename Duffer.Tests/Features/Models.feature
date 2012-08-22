Feature: 'Model' nodes
	In order to create useful IDTF files
	I want to be able to write out Model definitionss

Scenario: scene with one model
	Given I have a new current scene
	And the current scene contains a model named "Box01" 
	And the model named "Box01" has a parent called "Parent1" 
	And the model named "Box01" has a resource called "BoxModel"
	And the parent named "Parent1" has an identity transform matrix
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "MODEL" {
		NODE_NAME "Box01"
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
		RESOURCE_NAME "BoxModel"
	}

	"""

Scenario: scene with two model nodes
	Given I have a new current scene
	And the current scene contains a model named "Box01" 
	And the model named "Box01" has a parent called "Parent1" 
	And the model named "Box01" has a resource called "BoxModel"
	And the parent named "Parent1" has an identity transform matrix
	And the current scene contains a model named "Box02" 
	And the model named "Box02" has a parent called "Box_Group" 
	And the model named "Box02" has a resource called "LightBoxModel"
	And the parent named "Box_Group" has an translation only transform matrix of "25", "26, "27"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "MODEL" {
		NODE_NAME "Box01"
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
		RESOURCE_NAME "BoxModel"
	}

	NODE "MODEL" {
		NODE_NAME "Box02"
		PARENT_LIST {
			PARENT_COUNT 1
			PARENT 0 {
				PARENT_NAME "Box_Group"
				PARENT_TM {
					1.000000 0.000000 0.000000 0.000000
					0.000000 1.000000 0.000000 0.000000
					0.000000 0.000000 1.000000 0.000000
					25.000000 26.000000 27.000000 1.000000
				}
			}
		}
		RESOURCE_NAME "LightBoxModel"
	}

	"""