
 
 

 

/// <reference path="Enums.ts" />

declare module FPS.Service.Models {
	interface ApartmentServiceModel {
		contactNumber1: string;
		contactNumber2: string;
		contactNumber3: string;
		firstName: string;
		id: number;
		isDeleted: boolean;
		lastName: string;
		livingEnd: Date;
		livingStart: Date;
		membersLiving: number;
		middleName: string;
		number: number;
		onRent: boolean;
		ownerContactNumber1: string;
		ownerContactNumber2: string;
		ownerContactNumber3: string;
		ownerFirstName: string;
		ownerId: number;
		ownerLastName: string;
		ownerLivingEnd: Date;
		ownerLivingStart: Date;
		ownerMembersLiving: number;
		ownerMiddleName: string;
		residentId: number;
	}
	interface ResidentServiceModel {
		contactNumber1: string;
		contactNumber2: string;
		contactNumber3: string;
		firstName: string;
		id: number;
		isDeleted: boolean;
		lastName: string;
		livingEnd: Date;
		livingStart: Date;
		membersLiving: number;
		middleName: string;
		onRent: boolean;
	}
}


