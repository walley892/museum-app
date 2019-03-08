// Fill out your copyright notice in the Description page of Project Settings.

#include "ARMaster.h"
#include "ARController.h"
#include "Engine.h"
#include <GoogleARCoreSessionConfig.h>
#include <GoogleARCoreFunctionLibrary.h>
#include <ARTrackable.h>

UCLASS()
class AARMaster : public AARMaster
{
	GENERATED_BODY()
public:
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "config")
		UGoogleARCoreSessionConfig* arcoreConfig;

	TMap<FString, FString> spawnedModels;
};

// Sets default values
AARMaster::AARMaster()
{
 	
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AARMaster::BeginPlay()
{

	FLatentActionInfo actionInfo;

	UGoogleARCoreSessionFunctionLibrary::StartARCoreSession(GetWorld(), actionInfo, arcoreConfig);
	
	Super::BeginPlay();
	
}

// Called every frame
void AARMaster::Tick(float DeltaTime)
{
	TArray<UGoogleARCoreAugmentedImage*> trackedImages;
	UGoogleARCoreSessionFunctionLibrary::GetAllAugmentedImages(trackedImages);
	if (trackedImages.Num > 0) {
		FString name = trackedImages[0]->GetImageName();
		if (spawnedModels.Contains(name)) {
			printf("Model already spawned");
		}
		else {
			printf("Spawing model");
			SpawnModel(name, trackedImages[0]->GetLocalToWorldTransform());
			spawnedModels.Add(name);
		}
	}
	
	Super::Tick(DeltaTime);

}
void AARMaster::SpawnModel(FString modelId, FTransform tf) {

}


