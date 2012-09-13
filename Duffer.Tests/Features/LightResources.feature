Feature: 'Light' resources
	In order to create useful IDTF files 
	I want to be able to write out light resource list definitions

@mytag
Scenario: scene with one shader resource
	Given I have a new current scene
	And the current scene contains a light resource list with a resource named "DefaultPointLight" 
	And the "DefaultPointLight" resource is of type "point" and has an intensity of "1"
	And the "DefaultPointLight" resource has a light color of "1", "1", "1" and attenuaion of "1", "0", "0"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "LIGHT" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "DefaultPointLight"
			LIGHT_TYPE "POINT"
			LIGHT_COLOR 1.000000 1.000000 1.000000
			LIGHT_ATTENUATION 1.000000 0.000000 0.000000
			LIGHT_INTENSITY 1.000000
		}
	}

	"""