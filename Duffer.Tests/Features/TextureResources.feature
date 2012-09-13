Feature: 'Texture' resources
	In order to create useful IDTF files 
	I want to be able to write out Texture resource list definitions

@mytag
Scenario: scene with four texture resources
	Given I have a new current scene
	And the current scene contains a texture resource named "Texture0" with path "mat1.tga"
	And the current scene contains a texture resource named "Texture1" with path "mat2.tga" 
	And the current scene contains a texture resource named "Texture2" with path "mat3.tga" 
	And the current scene contains a texture resource named "Texture3" with path "mat4.tga" 
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "TEXTURE" {
		RESOURCE_COUNT 4
		RESOURCE 0 {
			RESOURCE_NAME "Texture0"
			TEXTURE_PATH "mat1.tga"
		}
		RESOURCE 1 {
			RESOURCE_NAME "Texture1"
			TEXTURE_PATH "mat2.tga"
		}
		RESOURCE 2 {
			RESOURCE_NAME "Texture2"
			TEXTURE_PATH "mat3.tga"
		}
		RESOURCE 3 {
			RESOURCE_NAME "Texture3"
			TEXTURE_PATH "mat4.tga"
		}
	}

	"""

@mytag
Scenario: scene with one texture that contains two image formats
	Given I have a new current scene
	And the current scene contains a texture resource named "lines" with path "lines_alpha.tga"	
	And the texture resource "lines" has image type "RGBA"
	And the texture resource "lines" contains an image format list: compression type is "JPEG24" and bleu, green and red channel is "true", "true", "true"
	And the texture resource "lines" contains a second image format list: compression type is "PNG" and alpha channel is "true"
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	RESOURCE_LIST "TEXTURE" {
		RESOURCE_COUNT 1
		RESOURCE 0 {
			RESOURCE_NAME "lines"
			TEXTURE_IMAGE_TYPE "RGBA"
			TEXTURE_IMAGE_COUNT 2
			IMAGE_FORMAT_LIST {
				IMAGE_FORMAT 0 {
					COMPRESSION_TYPE "JPEG24"
					BLUE_CHANNEL "TRUE"
					GREEN_CHANNEL "TRUE"
					RED_CHANNEL "TRUE"
				}
				IMAGE_FORMAT 1 {
					COMPRESSION_TYPE "PNG"
					ALPHA_CHANNEL "TRUE"
				}
			}
			TEXTURE_PATH "lines_alpha.tga"
		}
	}

	"""
