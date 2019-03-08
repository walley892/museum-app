// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"

#include "ARMaster.generated.h"

UCLASS()
class MUSEUMAPP_API AARMaster : public APawn
{
	GENERATED_BODY()

public:
	AARMaster();

protected:
	virtual void BeginPlay() override;

public:	
	//Spawns the model with the given ID on the given FTransform
	void SpawnModel(FString modelId, FTransform spawnPoint);
	//Function that's called when the screen is touched
	void OnScreenTouch(FVector loc);
	virtual void Tick(float DeltaTime) override;
};
