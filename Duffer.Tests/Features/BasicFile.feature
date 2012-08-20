Feature: Basic File output
	In order to use the library
	I want to be able to write basic IDTF files

@mytag
Scenario: empty model
	Given I have a new current scene
	When I export the current scene to a file
	Then the contents of the current file should be
	"""
	FILE_FORMAT "IDTF"
	FORMAT_VERSION 100

	"""
