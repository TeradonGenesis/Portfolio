//
//  Person2.swift
//  FilteredListSwift
//
//  Created by Nicole Ronald on 4/20/16.
//  Copyright © 2016 Swinburne. All rights reserved.
//

import Foundation
import CoreData

class Person: NSManagedObject {
    @NSManaged var firstName: String?
    @NSManaged var lastName: String?
    @NSManaged var gender: String?
    
    
}

