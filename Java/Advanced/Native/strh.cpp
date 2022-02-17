#include "StringHelper.h"


JNIEXPORT jint JNICALL Java_StringHelper_hashOf(JNIEnv* env, jclass cls, jstring str)
{
	jint result = 0;
	jint n = env->GetStringLength(str);
	jboolean iscopy;
	const jchar* buffer = env->GetStringChars(str, &iscopy);

	for(jint i = 0; i < n; ++i)
	{
		result = buffer[i] + (result << 6) + (result << 16) - result;
	}

	env->ReleaseStringChars(str, buffer);

	return result;
}

JNIEXPORT jstring JNICALL Java_StringHelper_reverseOf(JNIEnv* env, jclass cls, jstring str)
{
	jint n = env->GetStringLength(str);
	jchar* buffer = new jchar[n];
	env->GetStringRegion(str, 0, n, buffer);

	for(jint i = 0, j = n - 1; i < j; ++i, j--)
	{
		jchar ic = buffer[i];
		jchar jc = buffer[j];
		buffer[i] = jc;
		buffer[j] = ic;
	}

	jstring result = env->NewString(buffer, n);
	delete[] buffer;

	return result;
}
