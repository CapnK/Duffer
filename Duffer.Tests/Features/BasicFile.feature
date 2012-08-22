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

Scenario: scene with one group
	Given I have a new current scene
	And the current scene contains a group named "Group1" 
	And the group named "Group1" has a parent called "Parent1" 
	And the parent named "Parent1" has an identity transform matrix
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "GROUP" {
		NODE_NAME "Group1"
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
	}

	"""

Scenario: scene with a group and two parents
	Given I have a new current scene
	And the current scene contains a group named "Group1"
	And the group named "Group1" has a parent called "Parent1" 
	And the parent named "Parent1" has an identity transform matrix
	And the group named "Group1" has a parent called "Parent2" 
	And the parent named "Parent2" has an identity transform matrix
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "GROUP" {
		NODE_NAME "Group1"
		PARENT_LIST {
			PARENT_COUNT 2
			PARENT 0 {
				PARENT_NAME "Parent1"
				PARENT_TM {
					1.000000 0.000000 0.000000 0.000000
					0.000000 1.000000 0.000000 0.000000
					0.000000 0.000000 1.000000 0.000000
					0.000000 0.000000 0.000000 1.000000
				}
			}
			PARENT 1 {
				PARENT_NAME "Parent2"
				PARENT_TM {
					1.000000 0.000000 0.000000 0.000000
					0.000000 1.000000 0.000000 0.000000
					0.000000 0.000000 1.000000 0.000000
					0.000000 0.000000 0.000000 1.000000
				}
			}
		}
	}

	"""


Scenario: scene with two groups and one parent each
	Given I have a new current scene
	And the current scene contains a group named "Group1"
	And the current scene contains a group named "Group2"
	And the group named "Group1" has a parent called "Parent1" 
	And the parent named "Parent1" has an identity transform matrix
	And the group named "Group2" has a parent called "Parent2" 
	And the parent named "Parent2" has an identity transform matrix
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	NODE "GROUP" {
		NODE_NAME "Group1"
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
	}

	NODE "GROUP" {
		NODE_NAME "Group2"
		PARENT_LIST {
			PARENT_COUNT 1
			PARENT 0 {
				PARENT_NAME "Parent2"
				PARENT_TM {
					1.000000 0.000000 0.000000 0.000000
					0.000000 1.000000 0.000000 0.000000
					0.000000 0.000000 1.000000 0.000000
					0.000000 0.000000 0.000000 1.000000
				}
			}
		}
	}

	"""
