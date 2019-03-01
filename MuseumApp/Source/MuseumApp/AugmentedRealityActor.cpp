// Fill out your copyright notice in the Description page of Project Settings.

#include "AugmentedRealityActor.h"
#include <GoogleARCoreSessionConfig.h>
#include <GoogleARCoreAugmentedImage.h>
#include <ARSessionConfig.h>
#include <GoogleARCoreFunctionLibrary.h>
#include <Color.h>


// Sets default values
AAugmentedRealityActor::AAugmentedRealityActor()
{
	InitAR();
	PrimaryActorTick.bCanEverTick = true;
	
}

void InitAR() {

	//Initalize Google ARCore Session
	UGoogleARCoreSessionConfig::CreateARCoreSessionConfig(
		//Horizontal plane tracking
		true,
		//Vertical plane tracking
		false,
		//Light estimation mode
		EARLightEstimationMode::AmbientLightEstimate,
		//Make sure the augmented reality components aren't lagging/leading camera feed frames
		EARFrameSyncMode::SyncTickWithCameraImage,
		//Auto focus
		true,
		//Automatically grab camera feed
		true,
		//Automatically start tracking based on camera feed
		true
	);
}



// Called when the game starts or when spawned
void AAugmentedRealityActor::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AAugmentedRealityActor::Tick(float DeltaTime)
{


	TArray<UGoogleARCoreAugmentedImage *> trackedImages;
	UGoogleARCoreSessionFunctionLibrary::GetAllAugmentedImages(trackedImages);

	//When the dollar bill is tracked, draw a red line around it

	if (trackedImages.Num() >= 1) {
		if (trackedImages[0]->GetImageName() == "DollarBill") {
			trackedImages[0]->DebugDraw(GetWorld(), FColor::Red, 0.1, 5);
		}
	}


	Super::Tick(DeltaTime);

}

