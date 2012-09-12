Feature: 'Shader' resources
	In order to create useful IDTF files 
	I want to be able to write out Shader resource list definitions

@mytag
Scenario: scene with one shader resource
	Given I have a new current scene
	And the current scene contains a shader resource list with a resource named "ModelShader0" 
	And the "ModelShader0" resource property for vertex colors is "true" and the material name is "Mat01" 
	And the "ModelShader0" resource has a texture layer called "Texture0"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "SHADER" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "ModelShader0"
			ATTRIBUTE_USE_VERTEX_COLOR "TRUE"
			SHADER_MATERIAL_NAME "Mat01"
			SHADER_ACTIVE_TEXTURE_COUNT 1
			SHADER_TEXTURE_LAYER_LIST {
				TEXTURE_LAYER 0 {
					TEXTURE_NAME "Texture0"
				}
			}
		}
	}

	"""

@mytag
Scenario: scene with three shader resources
	Given I have a new current scene
	And the current scene contains a shader resource list with the following resources "Box010", "Box020", "Box030"	
	And "Box010" has the following properties: material name is "Mat01" 
	And "Box020" has the following properties: material name is "Mat02"
	And "Box030" has the following properties: material name is "Mat03"	
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "SHADER" {
		RESOURCE_COUNT 3
		RESOURCE 0 {
			RESOURCE_NAME "Box010"
			SHADER_MATERIAL_NAME "Mat01"
			SHADER_ACTIVE_TEXTURE_COUNT 0
		}
		RESOURCE 1 {
			RESOURCE_NAME "Box020"
			SHADER_MATERIAL_NAME "Mat02"
			SHADER_ACTIVE_TEXTURE_COUNT 0
		}
		RESOURCE 2 {
			RESOURCE_NAME "Box030"
			SHADER_MATERIAL_NAME "Mat03"
			SHADER_ACTIVE_TEXTURE_COUNT 0
		}
	}

	"""


@mytag
Scenario: scene with three shader resources with different texture lists
	Given I have a new current scene
	And the current scene contains a shader resource list with the following resources "ModelShader1", "ModelShader2", "ModelShader3"
	And "ModelShader1" has the following properties: material name is "Material1" 
	And "ModelShader2" has the following properties: material name is "Material2"
	And "ModelShader3" has the following properties: material name is "Material3"		
	And the "ModelShader1" resource has two texture layers called "Texture2" and "Texture RGB"
	And the "ModelShader2" resource has a texture layer called "Lines Texture"
	And the "ModelShader3" resource has a texture layer called "Texture3"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "SHADER" {
		RESOURCE_COUNT 3
		RESOURCE 0 {
			RESOURCE_NAME "ModelShader1"
			SHADER_MATERIAL_NAME "Material1"
			SHADER_ACTIVE_TEXTURE_COUNT 2
			SHADER_TEXTURE_LAYER_LIST {
				TEXTURE_LAYER 0 {
					TEXTURE_NAME "Texture2"
				}
				TEXTURE_LAYER 1 {
					TEXTURE_NAME "Texture RGB"
				}
			}
		}
		RESOURCE 1 {
			RESOURCE_NAME "ModelShader2"
			SHADER_MATERIAL_NAME "Material2"
			SHADER_ACTIVE_TEXTURE_COUNT 1
			SHADER_TEXTURE_LAYER_LIST {
				TEXTURE_LAYER 0 {
					TEXTURE_NAME "Lines Texture"
				}
			}
		}
		RESOURCE 2 {
			RESOURCE_NAME "ModelShader3"
			SHADER_MATERIAL_NAME "Material3"
			SHADER_ACTIVE_TEXTURE_COUNT 1
			SHADER_TEXTURE_LAYER_LIST {
				TEXTURE_LAYER 0 {
					TEXTURE_NAME "Texture3"
				}
			}
		}
	}

	"""

@mytag
Scenario: scene with one shader resource with many texture properties
	Given I have a new current scene
	And the current scene contains a shader resource list with a resource named "ModelShader1" 
	And "ModelShader1" has the following properties: material name is "ModelMaterial1" 
	And the "ModelShader1" resource has a texture layer called "lines"
	And the texture layer "lines" has the following properties: "1", "MULTIPLY", "CONSTANT", "0.5", "true"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "SHADER" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "ModelShader1"
			SHADER_MATERIAL_NAME "ModelMaterial1"
			SHADER_ACTIVE_TEXTURE_COUNT 1
			SHADER_TEXTURE_LAYER_LIST {
				TEXTURE_LAYER 0 {
					TEXTURE_LAYER_INTENSITY 1.000000
					TEXTURE_LAYER_BLEND_FUNCTION "MULTIPLY"
					TEXTURE_LAYER_BLEND_SOURCE "CONSTANT"
					TEXTURE_LAYER_BLEND_CONSTANT 0.500000
					TEXTURE_LAYER_ALPHA_ENABLED "TRUE"
					TEXTURE_NAME "lines"
				}
			}
		}
	}

	"""