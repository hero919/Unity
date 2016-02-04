using UnityEngine;
using System.Collections;

public class TestHarness {

	// How many tests have succeeded.
	static uint passed_tests;
	// How many tests have occured in total.
	static uint total_tests;
	// Whether or not to log results to an errorlog.
	public const bool run_tests = true;
	

	
	// Checks if some test passed (if the second argument is true) and
	// records the result.
	public static void check_test(string test_name, bool test_result) {
		if (run_tests) {
			if (test_result) {
				pass_test(test_name);
			} else {
				fail_test(test_name);
			}
		}
	}
	
	// Records that a given test passed.
	static void pass_test(string test_name) {
		passed_tests++;
		total_tests++;
		string output = ">>> " + test_name + " passed...";
		Debug.Log(output);
	}
	
	// Records that a given test failed.
	static void fail_test(string test_name) {
		total_tests++;
		string output = ">>> " + test_name + " failed...";
		Debug.Log(output);
	}
	
	// Resets the number of passed and total tests so far.
	public static void reset_testing() {
		passed_tests = 0;
		total_tests = 0;
	}
	
	// Prints out the sum results of the testing so far.
	public static void print_progress() {
		if (run_tests) {
			string output = "\n" + passed_tests.ToString() + " out of "
				+ total_tests.ToString() + " tests passed so far...\n";
			Debug.Log(output);
		}
	}
}
