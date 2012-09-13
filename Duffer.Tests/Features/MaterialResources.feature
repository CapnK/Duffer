Feature: 'Material' resources
	In order to create useful IDTF files 
	I want to be able to write out Material resource list definitions

@mytag
Scenario: scene with one material resource
	Given I have a new current scene
	And the current scene contains a material resource list with a resource named "Mat01" 
	And the "Mat01" resource properties for ambient material are "1", "1" and "1"
	And the "Mat01" resource properties for diffuse material are "1", "1" and "1"
	And the "Mat01" resource properties for specular material are "0", "0" and "0"
	And the "Mat01" resource properties for emissive material are "0", "0" and "0"
	And the "Mat01" resource property for material reflectivity is "0"
	And the "Mat01" resource property for material opacity is "1"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "MATERIAL" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "Mat01"
			MATERIAL_AMBIENT 1.000000 1.000000 1.000000
			MATERIAL_DIFFUSE 1.000000 1.000000 1.000000
			MATERIAL_SPECULAR 0.000000 0.000000 0.000000
			MATERIAL_EMISSIVE 0.000000 0.000000 0.000000
			MATERIAL_REFLECTIVITY 0.000000
			MATERIAL_OPACITY 1.000000
		}
	}

	"""