#!/bin/bash

set -e -x

nuget restore ValueUncertaintyGame/ValueUncertaintyGame.sln
xbuild ValueUncertaintyGame/ValueUncertaintyGame.sln
