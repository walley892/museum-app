// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "AugmentedModel.generated.h"

UCLASS()
class MUSEUMAPP_API AAugmentedModel : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AAugmentedModel();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
