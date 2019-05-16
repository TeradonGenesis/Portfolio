//
//  ViewController.swift
//  FilteredListSwift
//
//  Created by Nicole Ronald on 29/03/2016.
//  Copyright © 2016 Swinburne. All rights reserved.
//

import UIKit
import CoreData

class ViewController: UIViewController, UITableViewDataSource, UITableViewDelegate {

    @IBOutlet weak var filterControl: UISegmentedControl!
    @IBOutlet weak var sortControl: UISegmentedControl!
    @IBOutlet weak var actorTable: UITableView!
    
    
    
    var actors: [String] = []
    var people: [Person]!
    var managedObjectContext: NSManagedObjectContext!
    
    let sortDescriptorAsc = NSSortDescriptor(key: "lastName", ascending: true)
    let sortDescriptorDsc = NSSortDescriptor(key: "lastName", ascending: false)
    let filterM = NSPredicate(format: "gender == %@", "m")
    let filterF = NSPredicate(format: "gender == %@", "f")
    
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        
        
        //storing core data
        
        // Get our people array - this next block of code could probably be extracted out to a private
        // method and generalized for different fetch request types
        let personEntity = NSEntityDescription.entity(forEntityName: "Person", in:self.managedObjectContext)
        let request = NSFetchRequest<NSFetchRequestResult>()
        request.entity = personEntity
        do {
            self.people = try self.managedObjectContext.fetch(request) as? [Person]
        } catch {
            print("Could not fetch Core Data records")
        }

        actorTable.delegate = self
        actorTable.dataSource = self
        actorTable.reloadData()
        
        
        
        // TODO: add in code that reacts to the user changing the segmented controls
        // Hint: use either @IBActions or notifications (addTarget)


    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func numberOfSections(in tableView: UITableView) -> Int {
        return 1;
    }
    
    @IBAction func filtering(_ sender: Any) {
        
        let personEntity = NSEntityDescription.entity(forEntityName: "Person", in:self.managedObjectContext)
        let request = NSFetchRequest<NSFetchRequestResult>()
        request.entity = personEntity
        /*do {
            self.people = try self.managedObjectContext.fetch(request) as? [Person]
        } catch {
            print("Could not fetch Core Data records")
        }*/
   
        switch filterControl.selectedSegmentIndex {
        case 0:
            request.predicate = filterF
            if (sortControl.selectedSegmentIndex == 0) {
            
                request.sortDescriptors = [sortDescriptorAsc]
            } else if (sortControl.selectedSegmentIndex == 1) {
                request.sortDescriptors = [sortDescriptorDsc]
            }

        case 1:
            request.predicate = filterM
            if (sortControl.selectedSegmentIndex == 0) {
                
                request.sortDescriptors = [sortDescriptorAsc]
            } else if (sortControl.selectedSegmentIndex == 1) {
                request.sortDescriptors = [sortDescriptorDsc]
            }
            
        case 2:
            request.predicate = nil
            if (sortControl.selectedSegmentIndex == 0) {
                
                request.sortDescriptors = [sortDescriptorAsc]
            } else if (sortControl.selectedSegmentIndex == 1) {
                request.sortDescriptors = [sortDescriptorDsc]
            }
            
        default:
            break
        }
        
        do {
            self.people = try self.managedObjectContext.fetch(request) as? [Person]
        } catch {
            print("Could not fetch Core Data records")
        }
        
        actorTable.reloadData()

        
    }
    
    @IBAction func sorting(_ sender: Any) {
        let personEntity = NSEntityDescription.entity(forEntityName: "Person", in:self.managedObjectContext)
        let request = NSFetchRequest<NSFetchRequestResult>()
        request.entity = personEntity
        
        
        switch sortControl.selectedSegmentIndex {
        case 0:
            request.sortDescriptors = [sortDescriptorAsc]
            if (filterControl.selectedSegmentIndex == 0) {
                
                request.predicate = filterF
            } else if (filterControl.selectedSegmentIndex == 1) {
                request.predicate = filterM
            } else if (filterControl.selectedSegmentIndex == 2){
                request.predicate = nil
            }
            
        case 1:
            request.sortDescriptors = [sortDescriptorDsc]
            if (filterControl.selectedSegmentIndex == 0) {
                
                request.predicate = filterF
            } else if (filterControl.selectedSegmentIndex == 1) {
                request.predicate = filterM
            } else if (filterControl.selectedSegmentIndex == 2){
                request.predicate = nil
            }
            
        default:
            break
        }
        do {
            self.people = try self.managedObjectContext.fetch(request) as? [Person]
        } catch {
            print("Could not fetch Core Data records")
        }
        
        actorTable.reloadData()
    }
    
    /*@IBAction func sortAction(_ sender: Any) {
        let personEntity = NSEntityDescription.entity(forEntityName: "Person", in:self.managedObjectContext)
        let request = NSFetchRequest<NSFetchRequestResult>()
        request.entity = personEntity
        
        
        switch sortControl.selectedSegmentIndex {
        case 0:
            request.sortDescriptors = [sortDescriptorAsc]
            
        case 1:
            request.sortDescriptors = [sortDescriptorDsc]
            
        default:
            break
        }
        do {
            self.people = try self.managedObjectContext.fetch(request) as? [Person]
        } catch {
            print("Could not fetch Core Data records")
        }
        
        actorTable.reloadData()
    }*/
    
    
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return self.people.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = actorTable.dequeueReusableCell(withIdentifier: "PersonCell", for: indexPath)

        
        cell.textLabel?.text = "\(people[indexPath.row].lastName!), \(people[indexPath.row].firstName!)"
       
        return cell
    }
    
    
    
    
    
    


}

