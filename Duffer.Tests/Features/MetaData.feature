Feature: 'MetaData' nodes
	In order to create PDF files with 'attributes'
	I want to be able to write out Meta_Data with some node types

Scenario: scene with basic model meta data
	Given I have a new current scene
	And the current scene contains a model named "Box01" 
	And the model named "Box01" has a parent called "Parent1" 
	And the model named "Box01" has a resource called "BoxModel"
	And the parent named "Parent1" has an identity transform matrix
	And the metadata for the model named "Box01" has the following entries
	| key  | value  |
	| aKey | aValue |
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
		META_DATA {
			META_DATA_COUNT 1
			META_DATA 0 {
				META_DATA_ATTRIBUTE "STRING"
				META_DATA_KEY "aKey"
				META_DATA_VALUE "aValue"
			}
		}
	}
	"""

Scenario: scene with RHAdobeMeta model meta data
	Given I have a new current scene
	And the current scene contains a model named "Box01" 
	And the model named "Box01" has a parent called "Parent1" 
	And the model named "Box01" has a resource called "BoxModel"
	And the parent named "Parent1" has an identity transform matrix
	And the metadata for the model named "Box01" has a RHAdobeMeta entry with the following values
	| key     | value   |
	| Area    | 377.092 |
	| Density | 0.036   |
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
		META_DATA {
			META_DATA_COUNT 1
			META_DATA 0 {
				META_DATA_ATTRIBUTE "STRING"
				META_DATA_KEY "RHAdobeMeta"
				META_DATA_VALUE "<namespace name=\"24578\"> <item name=\"Area\" value=\"377.092\"/> <item name=\"Density\" value=\"0.036\"/> </namespace>"
			}
		}
	}

	"""