Feature: 'Shading' modifier
	In order to create useful IDTF files 
	I want to be able to write out shading modifier definitions

@mytag
Scenario: scene with one shading modifier
	Given I have a new current scene
	And I add a shading modifier called "Box01" with one shader list with a item "Box010" in the shader name list
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	MODIFIER "SHADING" {
		MODIFIER_NAME "Box01"
		PARAMETERS {
			SHADER_LIST_COUNT 1
			SHADING_GROUP {
				SHADER_LIST 0 {
					SHADER_COUNT 1
					SHADER_NAME_LIST {
						SHADER 0 NAME: "Box010"
					}
				}
			}
		}
	}

	"""

@mytag
Scenario: scene with two shading modifiers
	Given I have a new current scene
	And I add a shading modifier called "Box01" with one shader list with a item "Box010" in the shader name list
	And I add a shading modifier called "Box02" with one shader list with a item "Box020" in the shader name list
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	MODIFIER "SHADING" {
		MODIFIER_NAME "Box01"
		PARAMETERS {
			SHADER_LIST_COUNT 1
			SHADING_GROUP {
				SHADER_LIST 0 {
					SHADER_COUNT 1
					SHADER_NAME_LIST {
						SHADER 0 NAME: "Box010"
					}
				}
			}
		}
	}

	MODIFIER "SHADING" {
		MODIFIER_NAME "Box02"
		PARAMETERS {
			SHADER_LIST_COUNT 1
			SHADING_GROUP {
				SHADER_LIST 0 {
					SHADER_COUNT 1
					SHADER_NAME_LIST {
						SHADER 0 NAME: "Box020"
					}
				}
			}
		}
	}

	"""

@mytag
Scenario: scene with one shading modifiers containing two shaders
	Given I have a new current scene
	And I add a shading modifier called "Box01" with one shader list with a shader "ModelShader1" and a shader "ModelShader2"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	MODIFIER "SHADING" {
		MODIFIER_NAME "Box01"
		PARAMETERS {
			SHADER_LIST_COUNT 2
			SHADING_GROUP {
				SHADER_LIST 0 {
					SHADER_COUNT 1
					SHADER_NAME_LIST {
						SHADER 0 NAME: "ModelShader1"
					}
				}
				SHADER_LIST 1 {
					SHADER_COUNT 1
					SHADER_NAME_LIST {
						SHADER 0 NAME: "ModelShader2"
					}
				}
			}
		}
	}

	"""