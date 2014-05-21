/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_FEATURES2DBAGOFWORDS_H_
#define _CPP_FEATURES2DBAGOFWORDS_H_

#include "include_opencv.h"

#pragma region BOWKMeansTrainer

CVAPI(cv::BOWKMeansTrainer*) features2d_BOWKMeansTrainer_new(int clusterCount, CvTermCriteria termCrit, int attempts, int flags)
{
    return new cv::BOWKMeansTrainer(clusterCount, termCrit, attempts, flags);
}
CVAPI(void) features2d_BOWKMeansTrainer_delete(cv::BOWKMeansTrainer *obj)
{
	delete obj;
}

#pragma endregion

#endif
