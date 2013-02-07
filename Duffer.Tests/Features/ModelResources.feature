Feature: 'Model' resources
	In order to create useful IDTF files 
	I want to be able to write out model resource list definitions

@mytag
Scenario: scene with one model resource
	Given I have a new current scene
	And the current scene contains a model resource list with a "Mesh" resource named "LightBoxModel" 
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MODEL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "LightBoxModel"
			MODEL_TYPE "MESH"
		}
	}

	"""

@mytag
Scenario: scene with one model resource with empty mesh model
	Given I have a new current scene
	And the current scene contains a model resource list with a "Mesh" resource named "MyMesh01"
	And the resource "MyMesh01" contains an mesh model 
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MODEL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "MyMesh01"
			MODEL_TYPE "MESH"
			MESH {
				FACE_COUNT 0
				MODEL_POSITION_COUNT 0
				MODEL_NORMAL_COUNT 0
				MODEL_DIFFUSE_COLOR_COUNT 0
				MODEL_SPECULAR_COLOR_COUNT 0
				MODEL_TEXTURE_COORD_COUNT 0
				MODEL_BONE_COUNT 0
				MODEL_SHADING_COUNT 0
			}
		}
	}

	"""

@mytag
Scenario: scene with one model resource with empty line set model
	Given I have a new current scene
	And the current scene contains a model resource list with a "Line_Set" resource named "MyLineSet"
	And the resource "MyLineSet" contains a line set model 
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MODEL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "MyLineSet"
			MODEL_TYPE "LINE_SET"
			LINE_SET {
				LINE_COUNT 0
				MODEL_POSITION_COUNT 0
				MODEL_NORMAL_COUNT 0
				MODEL_DIFFUSE_COLOR_COUNT 0
				MODEL_SPECULAR_COLOR_COUNT 0
				MODEL_TEXTURE_COORD_COUNT 0
				MODEL_SHADING_COUNT 0
			}
		}
	}

	"""

@mytag
Scenario: scene with one model resource with "Mesh" with shading descriptions
	Given I have a new current scene
	And the current scene contains a model resource list with a "Mesh" resource named "MyMesh01"
	And the resource "MyMesh01" contains an mesh model 
	And the resource "MyMesh01" contains a shading description with id "0" and a texture layer with dimension "2" 
	And the resource "MyMesh01" contains a shading description with id "0" and a texture layer with dimension "1" 
	And the resource "MyMesh01" contains a shading description with id "0" and a texture layer with dimension "2" 
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MODEL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "MyMesh01"
			MODEL_TYPE "MESH"
			MESH {
				FACE_COUNT 0
				MODEL_POSITION_COUNT 0
				MODEL_NORMAL_COUNT 0
				MODEL_DIFFUSE_COLOR_COUNT 0
				MODEL_SPECULAR_COLOR_COUNT 0
				MODEL_TEXTURE_COORD_COUNT 0
				MODEL_BONE_COUNT 0
				MODEL_SHADING_COUNT 3
				MODEL_SHADING_DESCRIPTION_LIST {
					SHADING_DESCRIPTION 0 {
						TEXTURE_LAYER_COUNT 1
						TEXTURE_COORD_DIMENSION_LIST {
							TEXTURE_LAYER 0	DIMENSION: 2
						}
						SHADER_ID 0
					}
					SHADING_DESCRIPTION 1 {
						TEXTURE_LAYER_COUNT 1
						TEXTURE_COORD_DIMENSION_LIST {
							TEXTURE_LAYER 0	DIMENSION: 1
						}
						SHADER_ID 0
					}
					SHADING_DESCRIPTION 2 {
						TEXTURE_LAYER_COUNT 1
						TEXTURE_COORD_DIMENSION_LIST {
							TEXTURE_LAYER 0	DIMENSION: 2
						}
						SHADER_ID 0
					}
				}
			}
		}
	}

	"""

@mytag
Scenario: scene with one model resource containing a mesh with some random lists
	Given I have a new current scene
	And the current scene contains a model resource list with a "Mesh" resource named "LightBoxModel"
	And the resource "LightBoxModel" contains an mesh model 
	And the resource "LightBoxModel" contains a shading description with id "0" 
	And the resource "LightBoxModel" has a mesh face position "0", "2", "3"
	And the resource "LightBoxModel" has a mesh face position "3", "1", "0"
	And the resource "LightBoxModel" has a mesh face position "4", "5", "7"
	And the resource "LightBoxModel" has a mesh face position "7", "6", "4"
	And the resource "LightBoxModel" has a mesh face normal "0", "1", "2"
	And the resource "LightBoxModel" has a mesh face normal "3", "4", "5"
	And the resource "LightBoxModel" has a mesh face normal "6", "7", "8"
	And the resource "LightBoxModel" has a mesh face normal "9", "10", "11"
	And the resource "LightBoxModel" has a mesh face shading "0"
	And the resource "LightBoxModel" has a mesh face shading "0"
	And the resource "LightBoxModel" has a mesh face shading "0"
	And the resource "LightBoxModel" has a mesh face shading "0"
	And the resource "LightBoxModel" has a mesh position "-20", "-20", "0"
	And the resource "LightBoxModel" has a mesh position "20", "-20", "0"
	And the resource "LightBoxModel" has a mesh position "20", "-20", "40"
	And the resource "LightBoxModel" has a mesh position "-20", "20", "40"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MODEL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "LightBoxModel"
			MODEL_TYPE "MESH"
			MESH {
				FACE_COUNT 4
				MODEL_POSITION_COUNT 4
				MODEL_NORMAL_COUNT 0
				MODEL_DIFFUSE_COLOR_COUNT 0
				MODEL_SPECULAR_COLOR_COUNT 0
				MODEL_TEXTURE_COORD_COUNT 0
				MODEL_BONE_COUNT 0
				MODEL_SHADING_COUNT 1
				MODEL_SHADING_DESCRIPTION_LIST {
					SHADING_DESCRIPTION 0 {
						TEXTURE_LAYER_COUNT 0
						SHADER_ID 0
					}
				}
				MESH_FACE_POSITION_LIST {
					0 2 3
					3 1 0
					4 5 7
					7 6 4
				}
				MESH_FACE_NORMAL_LIST {
					0 1 2
					3 4 5
					6 7 8
					9 10 11
				}
				MESH_FACE_SHADING_LIST {
					0
					0
					0
					0
				}
				MODEL_POSITION_LIST {
					-20.000000 -20.000000 0.000000
					20.000000 -20.000000 0.000000
					20.000000 -20.000000 40.000000
					-20.000000 20.000000 40.000000
				}
			}
		}
	}

	"""

	
@mytag
Scenario: scene with one model resource containing some lines
	Given I have a new current scene
	And the current scene contains a model resource list with a "Line_Set" resource named "Lines"
	And the resource "Lines" contains a line set model 
	And the resource "Lines" contains a shading description with id "3" 
	And the resource called "Lines" contains lines
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MODEL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "Lines"
			MODEL_TYPE "LINE_SET"
			LINE_SET {
				LINE_COUNT 9
				MODEL_POSITION_COUNT 18
				MODEL_NORMAL_COUNT 9
				MODEL_DIFFUSE_COLOR_COUNT 0
				MODEL_SPECULAR_COLOR_COUNT 0
				MODEL_TEXTURE_COORD_COUNT 0
				MODEL_SHADING_COUNT 1
				MODEL_SHADING_DESCRIPTION_LIST {
					SHADING_DESCRIPTION 0 {
						TEXTURE_LAYER_COUNT 0
						SHADER_ID 3
					}
				}
				LINE_POSITION_LIST {
					0 1
					2 3
					4 5
					6 7
					8 9
					10 11
					12 13
					14 15
					16 17
				}
				LINE_NORMAL_LIST {
					0 0
					1 1
					2 2
					3 3
					3 0
					3 0
					3 0
					3 0
					3 0
				}
				LINE_SHADING_LIST {
					0
					0
					0
					0
					0
					0
					0
					0
					0
				}
				MODEL_POSITION_LIST {
					0.000000 0.000000 0.000000
					0.000000 20.000000 0.000000
					5.000000 0.000000 0.000000
					5.000000 20.000000 0.000000
					10.000000 0.000000 0.000000
					10.000000 20.000000 0.000000
					15.000000 0.000000 0.000000
					15.000000 20.000000 0.000000
					20.000000 0.000000 0.000000
					20.000000 20.000000 0.000000
					-5.000000 5.000000 0.000000
					20.000000 5.000000 0.000000
					-5.000000 10.000000 0.000000
					20.000000 10.000000 0.000000
					-5.000000 15.000000 0.000000
					20.000000 15.000000 0.000000
					-5.000000 20.000000 0.000000
					20.000000 20.000000 0.000000
				}
				MODEL_NORMAL_LIST {
					0.000000 0.500000 0.500000
					0.000000 0.200000 0.800000
					0.000000 0.000000 0.990000
					0.000000 0.000000 1.000000
					0.000000 0.000000 1.000000
					0.000000 0.000000 1.000000
					0.000000 0.000000 -1.000000
					0.000000 0.000000 -1.000000
					0.000000 0.000000 -1.000000
				}
			}
		}
	}

	"""