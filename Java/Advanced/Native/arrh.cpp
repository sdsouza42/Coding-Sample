#include "ArrayHelper.h"

JNIEXPORT jdouble JNICALL Java_ArrayHelper_sumOf(JNIEnv* env, jclass, jdoubleArray values)
{
	jdouble result = 0;
	jint n = env->GetArrayLength(values);
	jboolean iscopy;
	jdouble* entries = env->GetDoubleArrayElements(values, &iscopy);

	for(jint i = 0; i < n; ++i)
		result += entries[i];

	env->ReleaseDoubleArrayElements(values, entries, JNI_ABORT);

	return result;
}

JNIEXPORT void JNICALL Java_ArrayHelper_squareAll(JNIEnv* env, jclass, jdoubleArray values)
{
	jint n = env->GetArrayLength(values);
	jdouble* entries = new jdouble[n];
	env->GetDoubleArrayRegion(values, 0, n, entries);

	for(jint i = 0; i < n; ++i)
		entries[i] *= entries[i];
	
	env->SetDoubleArrayRegion(values, 0, n, entries);
	delete[] entries;
}

