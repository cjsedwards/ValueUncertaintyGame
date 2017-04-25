#!/bin/bash

set -e -x

nuget restore ValueUncertaintyGame/ValueUncertaintyGame.sln
xbuild ValueUncertaintyGame/ValueUncertaintyGame.sln
cp ValueUncertaintyGame/ValueUncertaintyGameRunner/bin/Debug/*.* ValueUncertaintyGameBuildResults
cp ValueUncertaintyGame/Dockerfile ValueUncertaintyGameBuildResults
